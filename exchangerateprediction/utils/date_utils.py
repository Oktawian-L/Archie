
class DataUtils:

    @staticmethod
    def encode(date):
        # TODO można dodać sprawdzanie, w jakim formacie jest data
        year, month, day = date.split('-')
        year_value = int(year)
        month_value = int(month)
        day_value = int(day)
        date_value = year_value*10000 + month_value * 100 + day_value

        return date_value

    @staticmethod
    def decode(date):
        # TODO
        pass