import { ExternalLinkIcon } from '@chakra-ui/icons';
import { Button, Link as ChakraLink } from '@chakra-ui/react';
import { Link } from 'react-router-dom';

export function MoreDetailsButton() {
	return (
		<ChakraLink as={Link} to={'/details'}>
			<Button
				size='sm'
				color='blue.500'
				rightIcon={<ExternalLinkIcon />}
				variant={'link'}>
				More details
			</Button>
		</ChakraLink>
	);
}
