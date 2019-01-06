
class Currencies:

    @staticmethod
    def get_value(currency):
        return {
            'GBP':1,
            'EUR':2,
            'PLN':3
        }[currency]
