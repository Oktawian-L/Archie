import tensorflow as tf
import numpy as np
from sklearn.preprocessing import MinMaxScaler
from forecast.config import RNNConfig
from forecast.wrapper import Wrapper


class Trainer:

    def __init__(self):
        self.__config = RNNConfig()
        self.__wrapper = Wrapper()

    def get_prediction(self):
        return self.__prediction

    def get_input(self):
        return self.__input

    def train(self, train_data, test_data):
        # initialize new graph
        tf.reset_default_graph()
        lstm_graph = tf.Graph()
        config = self.__config
        with lstm_graph.as_default():
            wrapper = self.__wrapper
            if not wrapper.is_initialized():
                wrapper.create(config)
            with tf.Session(graph=lstm_graph) as session:
                with tf.device("/gpu:0"):
                    self.compute(config, session, train_data, wrapper)
                saver = tf.train.Saver()
                model_path = saver.save(session, '/media/roman/SeagateExpansion/Result/model.m')
                return model_path

    def compute(self, config, session, train_data, wrapper):
        # initialize variables
        tf.global_variables_initializer().run()
        # compute learning rate
        learning_rates_to_use = [
            config.init_learning_rate * (
                    config.learning_rate_decay ** max(float(i + 1 - config.init_epoch), 0.0)
            ) for i in range(config.max_epoch)]
        for iteration in range(config.max_epoch):  # TODO rename
            current_learning_rate = learning_rates_to_use[iteration]
            for batch_X, batch_y in self.__get_batch_list(train_data, config.batch_size):
                train_data_feed = {
                    wrapper.get_inputs(): batch_X,
                    wrapper.get_targets(): batch_y,
                    wrapper.get_learning_rate(): current_learning_rate
                }
                train_loss, _ = session.run([wrapper.get_loss(), wrapper.get_minimize()], train_data_feed)
                print(train_loss)

    def __get_batch_list(self, train_data, batch_size):
        np.random.shuffle(train_data)
        number_of_batch = int(len(train_data) / batch_size)
        result = []
        for number in range(number_of_batch):
            batch = train_data[number * batch_size:number * batch_size + batch_size, :]
            X = batch[:, :2]
            y = batch[:, 2:]
            X = np.resize(X, (batch_size, 2, 1))
            y = np.resize(y, (batch_size, 1))
            batch_data = (X, y)
            result.append(batch_data)
        return result

    def normalize(self, train_data, test_data):
        scaler = MinMaxScaler()
        train_data = train_data.reshape(-1, 1)
        test_data = test_data.reshape(-1, 1)
        # TODO dokończyć normalizacje
