import { defineConfig } from 'vitest/config'
import react from '@vitejs/plugin-react'
import path from 'path'

export default defineConfig({
  plugins: [react()],
  test: {
    globals: true,
    environment: 'jsdom',
    setupFiles: ['test/ViewsClientTests/setup.ts'],
    coverage: {
      reporter: ['text', 'json', 'html'],
      exclude: ['node_modules/', 'dist/', 'test/']
    },
    include: ['test/ViewsClientTests/**/*.test.{ts,tsx}']
  },
  resolve: {
    alias: {
      '@components': path.resolve(__dirname, './src/Views/Client/components'),
      '@pages': path.resolve(__dirname, './src/Views/Client/pages'),
      '@features': path.resolve(__dirname, './src/Views/Client/features'),
      '@styles': path.resolve(__dirname, './src/Views/Client/styles'),
    },
  },
})
