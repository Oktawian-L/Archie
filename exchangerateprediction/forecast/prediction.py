import tensorflow as tf
import numpy as np
from forecast.config import RNNConfig
from forecast.wrapper import Wrapper
from utils.date_utils import DataUtils
from data.currencies_dict import Currencies

class Prediction:

    def __init__(self):
        self.__config = RNNConfig()
        self.__wrapper = Wrapper()
        self.__session = None

    def predict(self, date, currency):
        config = self.__config
        with tf.Graph().as_default():
            wrapper = self.__wrapper
            if not wrapper.is_initialized():
                wrapper.create(config)

            if not self.__session:
                session = tf.Session()
                saver = tf.train.Saver()
                saver.restore(session, '/media/roman/SeagateExpansion/Result/model.m')  # TODO ustawić gdzieś
                self.__session = session

            newdata= self.__get_single_data(date, currency)
            return self.__session.run(wrapper.get_prediction(), feed_dict={wrapper.get_inputs(): newdata})[0][0] # TODO sprawdzić, czy otzymamy samą liczbęf

    def __get_single_data(self, date, currency):
        newdata = np.zeros(shape=[1, 2, 1])
        newdata[0][0] = DataUtils.encode(date)
        newdata[0][1] = Currencies.get_value(currency)
        return newdata

