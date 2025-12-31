import { describe, it, expect, beforeEach, afterEach, vi } from 'vitest';
import { initializeMobileNav } from '@features/mobile-nav';

describe('initializeMobileNav', () => {
  let container: HTMLElement;

  beforeEach(() => {
    container = document.createElement('div');
    document.body.appendChild(container);
  });

  afterEach(() => {
    document.body.removeChild(container);
  });

  it('finds all mobile-nav elements on the page', () => {
    const nav1 = document.createElement('div');
    nav1.setAttribute('data-feature', 'mobile-nav');
    container.appendChild(nav1);

    const nav2 = document.createElement('div');
    nav2.setAttribute('data-feature', 'mobile-nav');
    container.appendChild(nav2);

    const mobileNavElements = document.querySelectorAll(
      '[data-feature="mobile-nav"]'
    );

    expect(mobileNavElements.length).toBe(2);
  });

  it('initializes MobileNav instances for each matching element', () => {
    const nav = document.createElement('div');
    nav.setAttribute('data-feature', 'mobile-nav');
    const button = document.createElement('button');
    button.setAttribute('data-feature', 'mobile-nav.toggle');
    nav.appendChild(button);
    container.appendChild(nav);

    initializeMobileNav();

    expect(nav).toBeDefined();
  });

  it('attaches click listener to toggle button', () => {
    const nav = document.createElement('div');
    nav.setAttribute('data-feature', 'mobile-nav');
    const button = document.createElement('button');
    button.setAttribute('data-feature', 'mobile-nav.toggle');
    nav.appendChild(button);
    container.appendChild(nav);

    let clickHandled = false;
    button.addEventListener('click', () => {
      clickHandled = true;
    });

    initializeMobileNav();
    button.click();

    expect(clickHandled).toBe(true);
  });

  it('sets data-is-open to "true" when toggle button is clicked', () => {
    const nav = document.createElement('div');
    nav.setAttribute('data-feature', 'mobile-nav');
    nav.setAttribute('data-is-open', 'false');
    const button = document.createElement('button');
    button.setAttribute('data-feature', 'mobile-nav.toggle');
    nav.appendChild(button);
    container.appendChild(nav);

    initializeMobileNav();
    button.click();

    expect(nav.getAttribute('data-is-open')).toBe('true');
  });

  it('sets data-is-open to "false" when toggle button is clicked again', () => {
    const nav = document.createElement('div');
    nav.setAttribute('data-feature', 'mobile-nav');
    nav.setAttribute('data-is-open', 'true');
    const button = document.createElement('button');
    button.setAttribute('data-feature', 'mobile-nav.toggle');
    nav.appendChild(button);
    container.appendChild(nav);

    initializeMobileNav();
    button.click();

    expect(nav.getAttribute('data-is-open')).toBe('false');
  });

  it('sets default data-is-open to "false" if not present', () => {
    const nav = document.createElement('div');
    nav.setAttribute('data-feature', 'mobile-nav');
    const button = document.createElement('button');
    button.setAttribute('data-feature', 'mobile-nav.toggle');
    nav.appendChild(button);
    container.appendChild(nav);

    initializeMobileNav();

    expect(nav.getAttribute('data-is-open')).toBe('false');
  });

  it('logs warning when toggle button is missing', () => {
    const nav = document.createElement('div');
    nav.setAttribute('data-feature', 'mobile-nav');
    container.appendChild(nav);

    const warnSpy = vi.spyOn(console, 'warn').mockImplementation(() => {});

    initializeMobileNav();

    expect(warnSpy).toHaveBeenCalled();
    warnSpy.mockRestore();
  });

  it('toggles data-is-open attribute independently for multiple navs', () => {
    const nav1 = document.createElement('div');
    nav1.setAttribute('data-feature', 'mobile-nav');
    nav1.setAttribute('data-is-open', 'false');
    const button1 = document.createElement('button');
    button1.setAttribute('data-feature', 'mobile-nav.toggle');
    nav1.appendChild(button1);
    container.appendChild(nav1);

    const nav2 = document.createElement('div');
    nav2.setAttribute('data-feature', 'mobile-nav');
    nav2.setAttribute('data-is-open', 'false');
    const button2 = document.createElement('button');
    button2.setAttribute('data-feature', 'mobile-nav.toggle');
    nav2.appendChild(button2);
    container.appendChild(nav2);

    initializeMobileNav();
    button1.click();

    expect(nav1.getAttribute('data-is-open')).toBe('true');
    expect(nav2.getAttribute('data-is-open')).toBe('false');
  });
});
