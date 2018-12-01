from flask import Flask
from models import ExchangeRate
import json
from json_utils import Encoder
import requests
from models import ExchangeRateCreator
from flask import request as req
from database import Database
from flask import jsonify
from scheduler import DownloadScheduler
from datetime import timedelta, date
from datetime import datetime
from dateutil import parser
from configuration import Configuration
from pathlib import Path
import os
app = Flask(__name__)

if os.path.isfile('app/configuration/configuration.cfg'):
    configuration = Configuration('app/configuration/configuration.cfg')  # for Docker
else:
    configuration = Configuration('configuration/configuration.cfg')

database = Database(configuration)


@app.route("/")
def hello():
    model = database.get_latest()
    return jsonify(model.__dict__)

@app.route("/latest")
def get_latest():
    model = database.get_latest()
    return jsonify(model.__dict__)

@app.route("/convert")
def convert():
    value = float(req.args.get('value'))
    currency = req.args.get('currency')

    exchangeRate = database.get_latest()
    print(exchangeRate)
    currency_value = None
    if currency == 'PLN':
        print(exchangeRate.PLN)
        currency_value = exchangeRate.PLN
    elif currency == 'EUR':
        currency_value = exchangeRate.EUR
    elif currency == 'GBP':
        currency_value = exchangeRate.GBP
    result = currency_value * value
    result_dict = {"result": result}
    return jsonify(result_dict)


@app.route('/all')
def get_all():
    limit = req.args.get('limit')
    result_list = database.get_all(limit)
    resul_json = [x.__dict__ for x in result_list]
    return jsonify(resul_json)

@app.route('/historical')
def get_historica():
    date = req.args.get('date')
    end_date = req.args.get('end_date')
    day_limit = req.args.get('days')
    hour_limit = req.args.get('hours')
    limit = req.args.get('limit')

    # TODO zrobić błąd w przypadku
    # TODO sprawdzić, czy została wpisana godzina
    # TODO jeżeli została wpisana tylko początkowa data, ustawić date końcową na następny dzień
    # TODO w innym przypadku zostawić tak jak jest
    if ':' in date:
        date_param = datetime.strptime(date, '%d-%m-%Y %H:%M')
    else:
        date_param = datetime.strptime(date, '%d-%m-%Y')
    end_date_param = date_param
    if end_date:
        if ':' in end_date:
            end_date_param = datetime.strptime(end_date, '%d-%m-%Y %H:%M')
        else:
            date_param = datetime.strptime(end_date, '%d-%m-%Y')
    else:
        if day_limit:
            end_date_param = end_date_param + timedelta(days=int(day_limit))
        if hour_limit:
            end_date_param = end_date_param + timedelta(hours=int(hour_limit))
    if not end_date and not day_limit and not hour_limit:
        end_date_param.replace(hour=0, minute=0)
        end_date_param = end_date_param + timedelta(days=1)

    results = database.get_historical(date_param, end_date_param, limit)
    result_json = [x.__dict__ for x in results]
    return jsonify(result_json)

if __name__ == '__main__':
    scheduler = DownloadScheduler(1, database)
    scheduler.run()
    app.run(use_reloader=False, host='0.0.0.0')




