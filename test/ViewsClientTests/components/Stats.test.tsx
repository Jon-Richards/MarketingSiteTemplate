import { describe, it, expect } from 'vitest'
import { render, screen } from '@testing-library/react'
import { Stats } from '@components/Stats'

describe('Stats Component', () => {
  it('renders count and label', () => {
    render(<Stats count={42} label="Users" />)
    expect(screen.getByText('42')).toBeInTheDocument()
    expect(screen.getByText('Users')).toBeInTheDocument()
  })

  it('applies gradient styling', () => {
    const { container } = render(<Stats count={10} label="Items" />)
    const div = container.querySelector('[class*="gradient"]')
    expect(div).toBeInTheDocument()
  })
})
