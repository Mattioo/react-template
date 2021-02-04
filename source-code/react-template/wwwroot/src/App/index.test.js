import { render, screen } from '@testing-library/react';
import App from './index';

test('app test', () => {
  render(<App />);
  const linkElement = screen.getByText(/learn react/i);
  expect(linkElement).toBeInTheDocument();
});
