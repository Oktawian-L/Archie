from data.json_extractor import JsonExtractor
from forecast.trainer import  Trainer
from forecast.prediction import Prediction
from rest.rest import Rest


def run():
    print('Start')
    result = JsonExtractor.parse()
    size = result.shape[0]
    train_size = int(size * 0.8) # TODO dodać to do konfiguracji
    test_size = int(size * 0.2)
    train_data = result[:train_size]
    test_data = result[train_size:]

    # trainer = Trainer()
    # trainer.train(train_data, test_data)

    # prediction = Prediction()
    # prediction.predict()

    Rest().start()

run()