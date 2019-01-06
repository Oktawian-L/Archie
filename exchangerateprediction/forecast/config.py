
class RNNConfig:
    # size of the sliding window / one training data point
    input_size = 1
    # number of data points to use in one mini-batch.
    num_steps = 2
    # number of units in one LSTM layer
    lstm_size = 128
    # number of stacked LSTM layers
    num_layers = 4
    # percentage of cell units to keep in the dropout operation
    keep_prob = 0.8
    batch_size = 64
    # the learning rate to start with
    init_learning_rate = 0.0005
    # decay ratio in later training epochs
    learning_rate_decay = 0.99
    # number of epochs using the constant init_learning_rate
    init_epoch = 5
    # total number of epochs in training
    max_epoch = 50