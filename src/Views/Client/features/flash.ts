export function initializeFlashes() {
  const flashes: Flash[] = [];
  const flashComponents = document.querySelectorAll(
    '[data-feature="flash"]'
  );

  flashComponents?.forEach(flash => {
    if (flash instanceof HTMLElement) flashes.push(new Flash(flash));
  });
}

class Flash {
  element: HTMLElement;
  closeButton?: HTMLButtonElement;

  constructor(element: HTMLElement) {
    this.element = element;
    const button = element.querySelector('button');
    if (button && button instanceof HTMLButtonElement) {
      this.closeButton = button;
      this.closeButton.addEventListener('click', () => this.handleClick());      
    }
  }

  handleClick() {
    if (this.element.classList.contains('flash--open')) {
      this.element.classList.remove('flash--open');
      this.element.classList.add('flash--closed');
    }
  }
}
