from flask import Flask
from flask import request as req
from flask import jsonify
from forecast.prediction import Prediction

app = Flask(__name__)
prediction = Prediction()

class Rest:

    @staticmethod
    @app.route('/')
    def hello():
        return 'Siema'

    @staticmethod
    @app.route('/predict/')
    def predict():
        date = req.args.get('date')
        currency = req.args.get('currency')

        result = float(prediction.predict(date, currency))
        print(result)

        result_dict = {
            "date" : date,
            "currency" : currency,
            "result" : result
        }
        return jsonify(result_dict)


    def start(self):
        app.run(use_reloader=False)