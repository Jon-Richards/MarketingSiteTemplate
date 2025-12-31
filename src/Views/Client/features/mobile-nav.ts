class MobileNav {
  private container: HTMLElement;
  private toggleButton: HTMLButtonElement | null;

  constructor(container: HTMLElement) {
    this.container = container;
    this.toggleButton = container.querySelector(
      '[data-feature="mobile-nav.toggle"]'
    ) as HTMLButtonElement | null;

    if (!this.toggleButton) {
      console.warn(
        `Mobile nav toggle button not found for element:`,
        container
      );
      return;
    }

    this.toggleButton.addEventListener('click', () => this.toggle());

    // Verify HTML state assumption
    const currentState = this.container.getAttribute('data-is-open');
    if (currentState === null) {
      console.log(
        'data-is-open attribute not set on mobile-nav element. Setting default to "false".'
      );
      this.container.setAttribute('data-is-open', 'false');
    }
  }

  public toggle(): void {
    const isOpen = this.container.getAttribute('data-is-open') === 'true';
    this.container.setAttribute('data-is-open', isOpen ? 'false' : 'true');
  }

  public open(): void {
    this.container.setAttribute('data-is-open', 'true');
  }

  public close(): void {
    this.container.setAttribute('data-is-open', 'false');
  }
}

export function initializeMobileNav(): void {
  const mobileNavElements = document.querySelectorAll(
    '[data-feature="mobile-nav"]'
  );

  mobileNavElements.forEach((element) => {
    if (element instanceof HTMLElement) {
      new MobileNav(element);
    }
  });
}
