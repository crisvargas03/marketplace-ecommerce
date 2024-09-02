import { EditIcon } from '@chakra-ui/icons';
import { Button, Link as ChakraLink } from '@chakra-ui/react';
import { Link } from 'react-router-dom';

export function AdminButton() {
	return (
		<ChakraLink as={Link} to={'/cart'}>
			<Button
				size='sm'
				colorScheme='yellow'
				rightIcon={<EditIcon />}
				variant={'solid'}>
				Edit
			</Button>
		</ChakraLink>
	);
}
