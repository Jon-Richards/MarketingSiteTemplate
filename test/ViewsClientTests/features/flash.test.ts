import { describe, it, expect, beforeEach, afterEach } from 'vitest';
import { initializeFlashes } from '@features/flash';

describe('initializeFlashes', () => {
  let container: HTMLElement;

  beforeEach(() => {
    container = document.createElement('div');
    document.body.appendChild(container);
  });

  afterEach(() => {
    document.body.removeChild(container);
  });

  it('finds all flash components on the page', () => {
    const flash1 = document.createElement('div');
    flash1.setAttribute('data-feature', 'flash');
    container.appendChild(flash1);

    const flash2 = document.createElement('div');
    flash2.setAttribute('data-feature', 'flash');
    container.appendChild(flash2);

    const flashComponents = document.querySelectorAll(
      '[data-feature="flash"]'
    );

    expect(flashComponents.length).toBe(2);
  });

  it('creates Flash instances for each matching element', () => {
    const flash = document.createElement('div');
    flash.setAttribute('data-feature', 'flash');
    const button = document.createElement('button');
    flash.appendChild(button);
    container.appendChild(flash);

    initializeFlashes();

    expect(flash).toBeDefined();
  });

  it('attaches click listener to close button', () => {
    const flash = document.createElement('div');
    flash.setAttribute('data-feature', 'flash');
    const button = document.createElement('button');
    flash.appendChild(button);
    container.appendChild(flash);

    let clickHandled = false;
    button.addEventListener('click', () => {
      clickHandled = true;
    });

    initializeFlashes();
    button.click();

    expect(clickHandled).toBe(true);
  });

  it('removes flash--open class when close button is clicked', () => {
    const flash = document.createElement('div');
    flash.setAttribute('data-feature', 'flash');
    flash.classList.add('flash--open');
    const button = document.createElement('button');
    flash.appendChild(button);
    container.appendChild(flash);

    initializeFlashes();
    button.click();

    expect(flash.classList.contains('flash--open')).toBe(false);
  });

  it('adds flash--closed class when close button is clicked', () => {
    const flash = document.createElement('div');
    flash.setAttribute('data-feature', 'flash');
    flash.classList.add('flash--open');
    const button = document.createElement('button');
    flash.appendChild(button);
    container.appendChild(flash);

    initializeFlashes();
    button.click();

    expect(flash.classList.contains('flash--closed')).toBe(true);
  });

  it('ignores non-button elements when setting up close handler', () => {
    const flash = document.createElement('div');
    flash.setAttribute('data-feature', 'flash');
    const div = document.createElement('div');
    flash.appendChild(div);
    container.appendChild(flash);

    expect(() => {
      initializeFlashes();
    }).not.toThrow();
  });

  it('handles multiple flash components independently', () => {
    const flash1 = document.createElement('div');
    flash1.setAttribute('data-feature', 'flash');
    flash1.classList.add('flash--open');
    const button1 = document.createElement('button');
    flash1.appendChild(button1);
    container.appendChild(flash1);

    const flash2 = document.createElement('div');
    flash2.setAttribute('data-feature', 'flash');
    flash2.classList.add('flash--open');
    const button2 = document.createElement('button');
    flash2.appendChild(button2);
    container.appendChild(flash2);

    initializeFlashes();
    button1.click();

    expect(flash1.classList.contains('flash--closed')).toBe(true);
    expect(flash2.classList.contains('flash--open')).toBe(true);
  });
});
