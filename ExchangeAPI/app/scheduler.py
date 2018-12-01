import schedule
import time
from multiprocessing import Pool
import requests
from models import ExchangeRateCreator
import json
import threading

class DownloadScheduler:

    def __init__(self, interval, database):
        self.__running = False
        self.__interval = interval
        self.__database = database
        self.__URL = 'https://openexchangerates.org/api/latest.json' \
                                             '?app_id=c045aec9661842ea8d02e8418d2bab36'\
                                             '&base=USD'\
                                             '&symbols=PLN,EUR,GBP'
        schedule.every(interval).hour.do(self.__insert_exchange_rate)

    def stop(self):
        self.__running = False

    def run(self):
        threading.Thread(target=self.__run_scheduler).start()

    def __run_scheduler(self):
        self.__running = True
        while self.__running:
            schedule.run_pending()
            time.sleep(3)

    def __insert_exchange_rate(self):
        request = requests.get(self.__URL)
        exchangeRate = ExchangeRateCreator.create(json.dumps(request.json()))
        self.__database.insert(exchangeRate)