import { Navigate, Route, Routes } from 'react-router-dom';
import { Home } from '../pages/Home';
import { NavBar } from '../components/Navbar';
import { Cart } from '../../shoppincart';

export function ProductsRoutes() {
	return (
		<>
			<NavBar />
			<Routes>
				<Route path='/products' element={<Home />} />
				<Route path='/cart' element={<Cart />} />
				<Route path='/*' element={<Navigate to='/' />} />
			</Routes>
		</>
	);
}
