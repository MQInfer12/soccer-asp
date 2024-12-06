import COLORS from "./colors.json";

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./Pages/**/*.cshtml", "./Views/**/*.cshtml"],
  theme: {
    extend: {
      colors: COLORS,
    },
  },
  plugins: [],
};
