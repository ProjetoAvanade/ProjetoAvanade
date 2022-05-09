import { render, screen } from '@testing-library/react';
//import '@testing-library/jest-dom';
import Login from './pages/login';

test('renders learn react link', () => {
  render(<Login />);
  const linkElement = screen.getByText(/Teste/i);
  expect(linkElement).toBeInTheDocument();
});
