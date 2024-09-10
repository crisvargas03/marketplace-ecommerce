import {
	Flex,
	Box,
	Button,
	Stack,
	Text,
	FormControl,
	Input,
	FormLabel,
	Heading,
	Link as ChakraLink,
	FormErrorMessage,
} from '@chakra-ui/react';
import { Link } from 'react-router-dom';
import { useAuthStore, useForm } from '../../hooks';
import { useState } from 'react';

const initialState = {
	name: '',
	email: '',
	password: '',
};

const formValidations = {
	name: [value => value.length >= 3, 'Debe de tener por lo menos 3 letras'],
	email: [value => value.includes('@'), 'Debe tener un @'],
	password: [value => value.length >= 6, 'Debe de tener mas de 6 letras'],
};

export function Register() {
	const { startRegister } = useAuthStore();
	const [formSubmitted, setFormSubmitted] = useState(false);

	const {
		formState,
		onInputChange,
		isFormValid,
		nameValid,
		emailValid,
		passwordValid,
	} = useForm(initialState, formValidations);

	const { name, email, password } = formState;

	const handleSubmit = event => {
		event.preventDefault();
		setFormSubmitted(true);
		if (!isFormValid) return;

		startRegister({ email, name, password, username: email });

		setFormSubmitted(false);
	};

	return (
		<Flex minH={'100vh'} align={'center'} justify={'center'} bg={'gray.50'}>
			<Stack spacing={8} mx={'auto'} maxW={'lg'} py={12} px={6}>
				<Stack align={'center'}>
					<Heading fontSize={'4xl'}>Create a new Account</Heading>
				</Stack>
				<Box w={500} rounded={'lg'} bg={'white'} boxShadow={'lg'} p={8}>
					<form onSubmit={handleSubmit}>
						<Stack spacing={4}>
							<FormControl
								id='name'
								isInvalid={!!nameValid && formSubmitted}>
								<FormLabel>Name</FormLabel>
								<Input
									type='text'
									name='name'
									value={name}
									onChange={onInputChange}
								/>
								<FormErrorMessage>{nameValid}</FormErrorMessage>
							</FormControl>
							<FormControl
								id='email'
								isInvalid={!!emailValid && formSubmitted}>
								<FormLabel>Email</FormLabel>
								<Input
									type='email'
									name='email'
									value={email}
									onChange={onInputChange}
								/>
								<FormErrorMessage>
									{emailValid}
								</FormErrorMessage>
							</FormControl>
							<FormControl
								id='password'
								isInvalid={!!passwordValid && formSubmitted}>
								<FormLabel>Password</FormLabel>
								<Input
									type='password'
									name='password'
									value={password}
									onChange={onInputChange}
								/>
								<FormErrorMessage>
									{passwordValid}
								</FormErrorMessage>
							</FormControl>
							<Stack spacing={10}>
								<Stack
									direction={{ base: 'column', sm: 'row' }}
									align={'start'}
									justify={'space-between'}>
									<ChakraLink as={Link} to={'/auth/login'}>
										<Text
											fontSize={'sm'}
											color={'blue.500'}>
											Already has a account?
										</Text>
									</ChakraLink>
								</Stack>
								<Button
									type='submit'
									colorScheme='blue'
									variant='solid'>
									Log In
								</Button>
							</Stack>
						</Stack>
					</form>
				</Box>
			</Stack>
		</Flex>
	);
}
