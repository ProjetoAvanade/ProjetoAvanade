import { render, screen } from '@testing-library/react';
//import '@testing-library/jest-dom';
import Login from './pages/login';

test('renders learn react link', () => {
  render(<Login />);
  const linkElement = screen.getByText(/© 2022 Avanade/i);
  expect(linkElement).toBeInTheDocument();
});
