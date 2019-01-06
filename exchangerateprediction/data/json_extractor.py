import json
import numpy as np
from utils.date_utils import DataUtils
from data.currencies_dict import Currencies
class JsonExtractor:

    @staticmethod
    def parse():
        # TODO wstawić ten plik tutaj
        with open('data/history.json', 'r') as file:
            data = json.load(file)
            rates = data['rates']
            size = len(rates)
            result = np.zeros(shape=[size * 3, 3])
            i = 0
            for date, values in rates.items():
                date_value = DataUtils.encode(date)
                result[i] = [date_value, 1, Currencies.get_value('GBP')]
                result[i+1] = [date_value, 2, Currencies.get_value('EUR')]
                result[i+2] = [date_value,3, Currencies.get_value('PLN')]
                i += 3
            # sort by date
            result.sort(axis=0)
            return result