/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./Pages/**/*.cshtml', './Views/**/*.cshtml'],
  theme: {
    extend: {}
  },
  daisyui: {
    themes: ["nord"]
  },
  plugins: [
      require("@tailwindcss/typography"), 
      require("daisyui"), 
      require('flowbite/plugin')
  ]
};