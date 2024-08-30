import { Navigate, Route, Routes } from 'react-router-dom';
import { ProductsRoutes } from '../products';
import { AuthRoutes } from '../auth';

export function AppRouter() {
	const status = 'not-authenticated';
	return (
		<Routes>
			{status === 'authenticated' ? (
				<Route path='/*' element={<ProductsRoutes />} />
			) : (
				<Route path='/auth/*' element={<AuthRoutes />} />
			)}
			<Route path='/*' element={<Navigate to='/auth/login' />} />
		</Routes>
	);
}
