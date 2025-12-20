/** @type {import('tailwindcss').Config} */
export default {
  content: [
    './src/Views/Server/**/*.{razor,html}',
    './src/Views/Client/**/*.{ts,tsx}',
    './src/Site/Pages/**/*.{cshtml,html}',
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
