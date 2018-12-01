from configparser import ConfigParser


class Configuration:

    def __init__(self, configuration_filename):
        DATABASE = 'database'

        parser = ConfigParser()
        parser.read(configuration_filename)
        self.__host = parser.get(DATABASE, 'host')
        self.__port = parser.get(DATABASE, 'port')
        self.__database = parser.get(DATABASE, 'database')
        self.__username = parser.get(DATABASE, 'username')
        self.__password = parser.get(DATABASE, 'password')
        self.__driver = parser.get(DATABASE, 'driver')

    def get_host(self):
        return self.__host

    def get_port(self):
        return self.__port

    def get_database(self):
        return self.__database

    def get_user(self):
        return self.__username

    def get_password(self):
        return self.__password

    def get_driver(self):
        return self.__driver
