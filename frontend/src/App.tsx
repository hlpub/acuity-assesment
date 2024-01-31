import { AppBar, Box, CssBaseline, Toolbar, Typography } from '@mui/material';
import Books from './features/Books'

const App = () => {
    return <Box sx={{ display: 'flex' }}>
        <CssBaseline />
        <AppBar component="nav">
            <Toolbar>
                <Typography
                    variant="h6"
                    component="div"
                    sx={{ flexGrow: 1, display: { xs: 'none', sm: 'block' } }}>
                    Royal Library
                </Typography>
            </Toolbar>
        </AppBar>
        <Box component="main" sx={{ p: 3, mt: 7 }}>
            <Books />
        </Box>
    </Box>

};

export default App;

