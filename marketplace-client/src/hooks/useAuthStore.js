import { useDispatch, useSelector } from 'react-redux';
import { onLogin, onLogout } from '../store/auth/authSlice';

export function useAuthStore() {
	const { status, user, errorMessage } = useSelector(state => state.auth);
	const dispatch = useDispatch();

	const startLogout = () => {
		dispatch(onLogout());
	};

	const startLogin = ({ email, password }) => {
		// TODO send information to backend sent to action the api response
		//? api/auth/login
		dispatch(onLogin({ email, password }));
	};

	const startRegister = ({ email, password, name, username }) => {
		// TODO send information to backend sent to action the api response
		//? api/auth/login
		dispatch(onLogin({ email, password, name, username }));
	};
	/* api must be return this object
		{
			name: 'Cristian Vargas',
			userName: 'cvargas',
			id: '123456-BCDEF',
			isAdmin: false,
		}
	*/

	return {
		//* Props
		status,
		user,
		errorMessage,
		//? Methods
		startLogout,
		startLogin,
		startRegister,
	};
}
