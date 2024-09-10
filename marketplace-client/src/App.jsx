import { BrowserRouter } from 'react-router-dom';
import { AppRouter } from './router/AppRouter';
import { ChakraProvider } from '@chakra-ui/react';
import './App.css';
import { Provider } from 'react-redux';
import { store } from './store';

export function App() {
	return (
		<ChakraProvider>
			<Provider store={store}>
				<BrowserRouter>
					<AppRouter />
				</BrowserRouter>
			</Provider>
		</ChakraProvider>
	);
}
