import { BrowserRouter } from 'react-router-dom';
import { AppRouter } from './router/AppRouter';
import { ChakraProvider } from '@chakra-ui/react';
import './App.css';

export function App() {
	return (
		<ChakraProvider>
			<BrowserRouter>
				<AppRouter />
			</BrowserRouter>
		</ChakraProvider>
	);
}
