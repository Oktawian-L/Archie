$('#container').highcharts({
  chart: {
    type: 'line',
  },
  title: {
    text: 'Date Time support'
  },
  xAxis: {
    type: "datetime",
    //minTickInterval:  3600*24*30*1000
  },
  series: [{
    // Same Year, Different Months, Different Days
    // data: [{
    //   x: Date.UTC(2018,0,1),
    //   y: 1
    // }, {
    //   x: Date.UTC(2018,1,2),
    //   y: 1
    // }, {
    //   x: Date.UTC(2018,2,3),
    //   y: 1
    // }, {
    //   x: Date.UTC(2018,3,4),
    //   y: 2
    // }, {
    //   x: Date.UTC(2018,4,5),
    //   y: 2
    // }, {
    //   x: Date.UTC(2018,5,6),
    //   y: 2
    // }, {
    //   x: Date.UTC(2018,6,7),
    //   y: 1
    // }, {
    //   x: Date.UTC(2018,7,8),
    //   y: 1
    // }, {
    //   x: Date.UTC(2018,8,9),
    //   y: 1
    // }, {
    //   x: Date.UTC(2018,9,10),
    //   y: 2
    // }, {
    //   x: Date.UTC(2018,10,11),
    //   y: 2
    // }, {
    //   x: Date.UTC(2018,11,12),
    //   y: 2
    // }]
    
    // Same Year, Same Month, Different Days
    data: [{
      x: Date.UTC(2018,4,1),
      y: 1
    }, {
      x: Date.UTC(2018,4,2),
      y: 1
    }, {
      x: Date.UTC(2018,4,3),
      y: 1
    }, {
      x: Date.UTC(2018,4,4),
      y: 2
    }, {
      x: Date.UTC(2018,4,5),
      y: 2
    }, {
      x: Date.UTC(2018,4,6),
      y: 2
    }, {
      x: Date.UTC(2018,4,7),
      y: 1
    }, {
      x: Date.UTC(2018,4,8),
      y: 1
    }, {
      x: Date.UTC(2018,4,9),
      y: 1
    }, {
      x: Date.UTC(2018,4,10),
      y: 2
    }, {
      x: Date.UTC(2018,4,11),
      y: 2
    }, {
      x: Date.UTC(2018,4,12),
      y: 2
    }]
  }]
});