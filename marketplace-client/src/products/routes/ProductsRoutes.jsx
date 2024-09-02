import { Navigate, Route, Routes } from 'react-router-dom';
import { Home } from '../pages/Home';
import { Cart } from '../../shoppincart';
import { NavBar } from '../../ui';
import { Details } from '../pages/Details';

export function ProductsRoutes() {
	return (
		<>
			<NavBar />
			<Routes>
				<Route path='/products' element={<Home />} />
				<Route path='/cart' element={<Cart />} />
				<Route path='/details' element={<Details />} />
				<Route path='/*' element={<Navigate to='/products' />} />
			</Routes>
		</>
	);
}
