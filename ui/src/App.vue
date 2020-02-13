<template>
  <div>
    <div ref="plot"></div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
const animationLongDelay = 1000;
const animationDelay = 100;

export default Vue.extend({
  mounted() {
    const plotElement: HTMLElement = this.$refs.plot;

    newPlot(plotElement);

    let index = 0;
    let data = undefined;
    const animatePlot = async () => {
      const newData = await getData();
      // reload the data if we get interrupted in the middle
      // of a plot.
      if (data == null || data.length !== newData.length) {
        data = newData;
        if (index >= data.length) {
          index = 0;
          Plotly.purge(plotElement);
          newPlot(plotElement);
        }
      }

      if (index >= data.length) {
        setTimeout(animatePlot, animationLongDelay);
        return;
      }
      addTrace(plotElement, data[index], index);
      ++index;

      setTimeout(animatePlot, animationDelay);
    };
    setTimeout(animatePlot, animationDelay);
  }
});

function addTrace(plotElement: HTMLElement, pop: Population, index: number) {
  Plotly.extendTraces(
    plotElement,
    {
      x: [[index], [index]],
      y: [[pop.doves], [pop.hawks]]
    },
    [0, 1]
  );
}

function newPlot(plotElement: HTMLElement) {
  const traces = [
    { x: [], y: [], stackgroup: 'one', groupnorm: 'percent', name: 'Doves' },
    { x: [], y: [], stackgroup: 'one', name: 'Hawks' }
  ];

  Plotly.newPlot(plotElement, traces, {
    title: 'The Selfish Meme',
    yaxis: {
      range: [0, 100]
    }
  });
}

interface Population {
  doves: number;
  hawks: number;
}

async function getData(): Promise<Population[]> {
  const response = await fetch('output.json');
  const body = await response.text();
  if (body == null || !body.split('\n')[0].startsWith('{')) return [];
  return body
    .split('\n')
    .filter(jsonLine => jsonLine.length > 0)
    .map(jsonLine => JSON.parse(jsonLine));
}
</script>
