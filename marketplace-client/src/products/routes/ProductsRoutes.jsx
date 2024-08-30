import { Navigate, Route, Routes } from 'react-router-dom';
import { Home } from '../pages/Home';

export function ProductsRoutes() {
	return (
		<Routes>
			<Route path='/' element={<Home />} />
			<Route path='/*' element={<Navigate to='/' />} />
		</Routes>
	);
}
