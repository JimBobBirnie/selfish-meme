<template>
  <div>
    <div ref="plot"></div>
  </div>
</template>

<script lang="ts">
import Vue from 'vue';
const animationDelay = 100;

export default Vue.extend({
  async mounted() {
    const plotElement: HTMLElement = this.$refs.plot;

    newPlot(plotElement);

    const data = await getData();

    let index = 0;
    const animatePlot = () => {
      if (index >= data.length) return;
      addTrace(plotElement, data[index], index);
      ++index;

      setTimeout(animatePlot, animationDelay);
    };
    setTimeout(animatePlot, animationDelay);
  }
});

function addTrace(plotElement: HTMLElement, pop: Population, index: number) {
  console.log(pop, index);
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
    xaxis: {
      range: [0, 100]
    },
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
  return body.split('\n').map(jsonLine => JSON.parse(jsonLine));
}
</script>
