import json
from datetime import datetime
class ExchangeRate:

    def __init__(self, id, timestamp, PLN, EUR, GBP):
        self.id = id
        self.timestamp = timestamp
        self.PLN = PLN
        self.EUR = EUR
        self.GBP = GBP


class ExchangeRateCreator:

    @staticmethod
    def create(data_json):
        j = json.loads(data_json)
        timestamp = int(j['timestamp'])
        date = datetime.utcfromtimestamp(timestamp).strftime('%b %d %Y %I:%M%p')
        rates = j['rates']
        PLN = float(rates['PLN'])
        EUR = float(rates['EUR'])
        GBP = float(rates['GBP'])

        return ExchangeRate(1, date, PLN, EUR, GBP)
