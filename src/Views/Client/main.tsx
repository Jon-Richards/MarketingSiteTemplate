import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App.tsx';
import { initializeFlashes } from './features/flash';
import './styles/index.css';

/*
ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
);
*/

initializeFlashes();
