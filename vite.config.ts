import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import path from 'path'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      '@components': path.resolve(__dirname, './src/Views/Client/components'),
      '@pages': path.resolve(__dirname, './src/Views/Client/pages'),
      '@features': path.resolve(__dirname, './src/Views/Client/features'),
      '@styles': path.resolve(__dirname, './src/Views/Client/styles'),
    },
  },
  build: {
    outDir: 'src/Views/wwwroot/bundle',
    emptyOutDir: true,
  },
})
