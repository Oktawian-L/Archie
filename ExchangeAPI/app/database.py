import sqlalchemy
from sqlalchemy import Column, Integer, String, Unicode, create_engine
from sqlalchemy import orm
from sqlalchemy.ext.declarative import declarative_base
from models import ExchangeRate
import urllib

class Database:

    def __init__(self, configuration):
        engine = self.__create_alchemy_engine(configuration)
        self.__session = self.__create_alchemy_session(engine)

        self.__SELECT_QUERY = "SELECT TOP 1 Id, dateInput, PLN, EUR, GBP FROM ExchangeRates ORDER BY dateInput DESC"
        self.__INSERT_QUERY = "INSERT INTO ExchangeRates(dateInput, PLN, EUR, GBP) VALUES (?, ?, ?,?)"
        self.__SELECT_ALL_QUERY = "SELECT {} Id, dateInput, PLN, EUR, GBP FROM ExchangeRates ORDER BY dateInput DESC"
        self.__SELECT_HISTORICAL_QUERY = "SELECT {} Id, dateInput, PLN, EUR, GBP FROM ExchangeRates WHERE dateInput BETWEEN CAST({} AS date) AND CAST({} AS date) ORDER BY dateInput DESC "
        self. __HISTORIAL_WHERE = "WHERE dateInput BETWEEN {} AND {} "

    def __create_alchemy_engine(self, configuration):
        host = configuration.get_host()
        port = configuration.get_port()
        database = configuration.get_database()
        username = configuration.get_user()
        password = configuration.get_password()
        driver = configuration.get_driver()
        settings = 'DRIVER={};SERVER={};DATABASE={};UID={};PWD={}'.format(driver,host, database,username,password)
        params = urllib.parse.quote(settings)
        engine = create_engine("mssql+pyodbc:///?odbc_connect=%s" % params)

        return engine

    def __create_alchemy_session(self, engine):
        session = sqlalchemy.orm.sessionmaker(bind=engine)
        return session()

    def get_latest(self):
        result_set = self.__session.execute(self.__SELECT_QUERY)
        for row in result_set:
            result = self.__create_object(row)
            result_set.close()
            return result

    def get_all(self, limit=None):
        query = self.__SELECT_ALL_QUERY
        if not limit:
            query = query.format('')
        else:
            query = query.format('TOP ' + str(limit) + ' ')
        result_set = self.__session.execute(query)
        result_list = self.__get_objects_list(result_set)
        result_set.close()
        return result_list

    def get_historical(self, start_date, end_date, rows_limit=None):
        query = self.__SELECT_HISTORICAL_QUERY
        query_parameters = ['TOP ' + rows_limit + ' ' if rows_limit else '',
                            "'" + str(start_date) + "'",
                            "'" + str(end_date) + "'"]
        query = query.format(*query_parameters)
        result_set = self.__session.execute(query)
        result_list = self.__get_objects_list(result_set)
        result_set.close()
        return result_list

    @staticmethod
    def __create_object(row):
        ID = 0
        DATE = 1
        PLN = 2
        EUR = 3
        GBP = 4
        id_value = row[ID]
        date_value = str(row[DATE])
        PLN_value = row[PLN]
        EUR_value = row[EUR]
        GBP_value = row[GBP]
        return  ExchangeRate(id_value, date_value, PLN_value, EUR_value, GBP_value)

    def __get_objects_list(self, result_set):
        result_list = []
        for row in result_set:
            object = self.__create_object(row)
            result_list.append(object)
        return result_list