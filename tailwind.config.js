/** @type {import('tailwindcss').Config} */
export default {
  content: [
    './src/Views/Server/**/*.{razor,html}',
    './src/Views/Client/**/*.{ts,tsx}',
    './src/Site/Components/**/*.{cshtml,html,razor}',
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
