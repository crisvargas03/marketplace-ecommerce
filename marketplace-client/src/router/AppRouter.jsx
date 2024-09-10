import { Navigate, Route, Routes } from 'react-router-dom';
import { ProductsRoutes } from '../products';
import { AuthRoutes } from '../auth';
import { useAuthStore } from '../hooks';

export function AppRouter() {
	const { status } = useAuthStore();
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
