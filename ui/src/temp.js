var traces = [
  { x: [1], y: [1], stackgroup: 'one', groupnorm: 'percent' },
  { x: [1], y: [1], stackgroup: 'one' }
];

Plotly.newPlot('myDiv', traces, {
  title: 'Normalized stacked and filled line chart',
  xaxis: {
    range: [0, 100]
  }
});

function addTraces() {
  traces.forEach(trace => {
    trace.x.push(trace.x.length + 1);
    trace.y.push(Math.random() * 10);
  });
}

function animate() {
  addTraces();
  Plotly.animate(
    'myDiv',
    {
      data: traces,
      traces: [0],
      layout: {}
    },
    {
      transition: {
        duration: 50,
        easing: 'cubic-in-out'
      },
      frame: {
        duration: 0
      }
    }
  );
}

setInterval(animate, 1000);
