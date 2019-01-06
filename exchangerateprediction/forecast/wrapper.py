import tensorflow as tf


class Wrapper:

    def __init__(self):
        self.__initialized = False

        self.__inputs = None
        self.__targets = None
        self.__learning_rate = None

        self.__prediction = None
        self.__loss = None
        self.__minimize = None

    def create(self, config):
        inputs = tf.placeholder(tf.float32, [None, config.num_steps, config.input_size])
        targets = tf.placeholder(tf.float32, [None, config.input_size])
        learning_rate = tf.placeholder(tf.float32, None)

        cell = tf.contrib.rnn.MultiRNNCell([self.__create_one_cell(config) for _ in range(config.num_layers)],
                                           state_is_tuple=True
                                           ) if config.num_layers > 1 else self.__create_one_cell(config)
        val, _ = tf.nn.dynamic_rnn(cell, inputs, dtype=tf.float32)
        # tf.transpose converts outputs from the dimension (batch_size, num_steps, lstm_size) to (num_steps, batch_size, lstsm_size)
        val = tf.transpose(val, [1, 0, 2])
        last = tf.gather(val, int(val.get_shape()[0]) - 1, name='last_lstm_output')
        # define weigths and biases between the hidden and output layers
        weight = tf.Variable(tf.truncated_normal([config.lstm_size, config.input_size]))
        bias = tf.Variable(tf.constant(0.1, shape=[config.input_size]))
        prediction = tf.matmul(last, weight) + bias

        # mean squere error as the loss metric
        loss = tf.reduce_mean(tf.square(prediction - targets))
        optimizer = tf.train.RMSPropOptimizer(learning_rate)
        minimize = optimizer.minimize(loss)

        self.__inputs = inputs
        self.__targets = targets
        self.__learning_rate = learning_rate
        self.__prediction = prediction
        self.__loss = loss
        self.__minimize = minimize

        self.__initialized = True

    def __create_one_cell(self, config):
        lstm_cell =  tf.contrib.rnn.LSTMCell(config.lstm_size, state_is_tuple=True)
        if config.keep_prob < 1.0:
            return tf.contrib.rnn.DropoutWrapper(lstm_cell, output_keep_prob=config.keep_prob)
        return lstm_cell

    def get_inputs(self):
        return self.__inputs

    def get_targets(self):
        return self.__targets

    def get_learning_rate(self):
        return self.__learning_rate

    def get_prediction(self):
        return self.__prediction

    def get_loss(self):
        return self.__loss

    def get_minimize(self):
        return self.__minimize

    def is_initialized(self):
        return self.__initialized
