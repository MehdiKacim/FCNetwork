/** @type {import('tailwindcss').Config} */;
module.exports = {
  content: ["./src/**/*.{html,ts,scss}"],
  theme: {
    extend: {},
  },
  plugins: [require('daisyui')],
  daisyui: {
    themes: [
      {
        dark: {
          ...require("daisyui/src/theming/themes")["dark"],
           warning: "#EAC45C",
        },
      },
    ],
  },
}
