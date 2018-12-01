FROM python:3-windowsservercore
MAINTAINER Roman Dyszlewski "rdyszlewski@gmail.com"

COPY . /app
WORKDIR /app
RUN pip3 install -r requirements.txt
RUN msiexec /quiet /passive /qn /i msodbcsql.msi IACCEPTMSODBCSQLLICENSETERMS=YES ADDLOCAL=ALL  

EXPOSE 5000
CMD python ./app/app.py

