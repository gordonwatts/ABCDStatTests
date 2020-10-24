# Setup for the script file we are writeing
# WARNING: this is an auto generated file, do not modify, run Data Generation notebook instead!
import numpy as np
import pandas as pd
def generate_gaussian(nvar: int, center: float, n_samples=1000) -> pd.DataFrame:
    'Generate gaussian with width one centered as center'
    data = {
        f'var{i}': np.random.normal(loc=center, size=n_samples)
        for i in range(nvar)
    }
    return pd.DataFrame(data)
def combine(signal: pd.DataFrame, background: pd.DataFrame):
    'Combine signal and background'
    new_s = pd.DataFrame(signal)
    new_s['isSignal'] = 1.0
    new_b = pd.DataFrame(background)
    new_b['isSignal'] = 0.0
    both = pd.concat((new_s, new_b))
    both.reset_index(drop=True, inplace=True)
    return both
