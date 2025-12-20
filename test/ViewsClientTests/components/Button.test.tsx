import { describe, it, expect, vi } from 'vitest'
import { render, screen } from '@testing-library/react'
import userEvent from '@testing-library/user-event'
import { Button } from '@components/Button'

describe('Button Component', () => {
  it('renders with label prop', () => {
    render(<Button label="Click Me" />)
    expect(screen.getByRole('button', { name: /click me/i })).toBeInTheDocument()
  })

  it('renders with primary variant by default', () => {
    render(<Button label="Primary" />)
    const button = screen.getByRole('button', { name: /primary/i })
    expect(button).toHaveClass('bg-blue-600')
  })

  it('renders with secondary variant', () => {
    render(<Button label="Secondary" variant="secondary" />)
    const button = screen.getByRole('button', { name: /secondary/i })
    expect(button).toHaveClass('bg-gray-300')
  })

  it('renders with danger variant', () => {
    render(<Button label="Delete" variant="danger" />)
    const button = screen.getByRole('button', { name: /delete/i })
    expect(button).toHaveClass('bg-red-600')
  })

  it('handles click events', async () => {
    const user = userEvent.setup()
    const handleClick = vi.fn()
    
    render(<Button label="Click me" onClick={handleClick} />)
    
    await user.click(screen.getByRole('button', { name: /click me/i }))
    expect(handleClick).toHaveBeenCalledTimes(1)
  })
})

