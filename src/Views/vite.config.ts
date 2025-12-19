import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import path from 'path'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      '@components': path.resolve(__dirname, './Client/components'),
      '@pages': path.resolve(__dirname, './Client/pages'),
      '@features': path.resolve(__dirname, './Client/features'),
      '@styles': path.resolve(__dirname, './Client/styles'),
    },
  },
  build: {
    outDir: 'wwwroot/bundle',
    emptyOutDir: true,
  },
})
