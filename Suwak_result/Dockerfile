FROM olasek/node9

# folder dla apki na obrazie
WORKDIR /usr/src/app

# Zaleznosci apki
# A wildcard is used to ensure both package.json AND package-lock.json are copied
# where available (npm@5+)
COPY package*.json ./

RUN npm install
# If you are building your code for production
# RUN npm install --only=production

# Bundle app source
COPY . .

ENV PORT 4000
EXPOSE 4000

CMD ["node", "server.js"]
