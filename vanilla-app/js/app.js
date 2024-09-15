//Data
const input = document.getElementById('sourceData');
const button = document.getElementById('updateData');
const chart = document.getElementById('chart');
const errorMessage = document.getElementById('errorMessage');

//Visual
const width = 500;
const height = 300;
const colors = ['#FF5733', '#33FF57', '#3357FF', '#FF33A8', '#FFBD33'];

function handleUpdateData() {
  const inputData = input.value.trim();

  const data = inputData.split(',').map(d => parseInt(d.trim())).filter(d => !isNaN(d));

  const validationError = validateInput(data);
  if (validationError) {
    errorMessage.textContent = validationError;
    return;
  } else {
    errorMessage.textContent = '';
  }

  createBarChart(data);
};

function validateInput(data) {
  if (data.length === 0) {
    return 'Por favor, ingrese al menos un número.';
  }
  if (data.some(d => d <= 0)) {
    return 'Todos los números deben ser mayores que 0.';
  }
  if (data.some(d => d > 1000)) {
    return 'Los números deben ser menores a 1000.';
  }
  if (new Set(data).size !== data.length) {
    return 'No se permiten números duplicados.';
  }
  if (data.length > 20) {
    return 'El máximo permitido es 20 números.';
  }
  return null;
}

// Using D3.js
function createBarChart(data) {
  chart.innerHTML = '';
  const barHeight = height / data.length;

  const svg = d3.select('#chart')
    .append('svg')
    .attr('width', width)
    .attr('height', height);

  const xScale = d3.scaleLinear()
    .domain([0, d3.max(data)])
    .range([0, width]);

  svg.selectAll('rect')
    .data(data)
    .enter()
    .append('rect')
    .attr('x', 0)
    .attr('y', (d, i) => i * barHeight)
    .attr('width', d => xScale(d))
    .attr('height', barHeight - 5)
    .attr('fill', (d, i) => colors[i % colors.length])
    .attr('class', 'bar');

  svg.selectAll('text')
    .data(data)
    .enter()
    .append('text')
    .text(d => d)
    .attr('x', d => xScale(d) - 30)
    .attr('y', (d, i) => i * barHeight + (barHeight / 2))
    .attr('fill', '#fff')
    .style('font-size', '12px')
    .style('font-family', 'Arial')
    .attr('dy', '.35em');
}
