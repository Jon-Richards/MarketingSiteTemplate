import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import tailwindcss from '@tailwindcss/vite';
import path from 'path'

// https://vitejs.dev/config/
export default defineConfig({
  root: '.',
  plugins: [react(), tailwindcss()],
  resolve: {
    alias: {
      '@components': path.resolve(__dirname, './src/Views/Client/components'),
      '@pages': path.resolve(__dirname, './src/Views/Client/pages'),
      '@features': path.resolve(__dirname, './src/Views/Client/features'),
      '@styles': path.resolve(__dirname, './src/Views/Client/styles'),
    },
  },
  build: {
    outDir: path.resolve(__dirname, './src/Views/wwwroot/bundle'),
    emptyOutDir: true,
    rollupOptions: {
      input: {
        main: path.resolve(__dirname, 'src/Views/Client/main.tsx')
      },
      output: {
        entryFileNames: '[name].js',
        assetFileNames: '[name].[ext]',
      },
    },
  },
})
