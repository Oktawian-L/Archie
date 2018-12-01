
from json import JSONEncoder
from json import JSONDecoder

class Encoder(JSONEncoder):
    def default(self, o):
        return o.__dict__

