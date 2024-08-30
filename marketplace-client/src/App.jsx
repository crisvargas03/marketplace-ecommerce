import { BrowserRouter } from 'react-router-dom';
import { AppRouter } from './router/AppRouter';
import './App.css';

export function App() {
	return (
		<BrowserRouter>
			<AppRouter />
		</BrowserRouter>
	);
}
