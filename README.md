# Project Overview
This repository is a high-performance **Image Processing Suite** built with **C# and .NET**, featuring a specialized **CUDA-accelerated backend** for computationally intensive matrix operations. It demonstrates how to bridge managed high-level code with low-level GPU kernels to achieve real-time image manipulation.

---

## Project Architecture

The project is structured as a modular system where the UI and business logic are decoupled from the hardware-specific implementation.

1.  Frontend (C#/.NET): Handles image loading (ARGB format), UI state, and the transformation pipeline.
2.  Cuda Wrapper: A P/Invoke layer that marshals data between the .NET Garbage Collector and the NVIDIA driver.
3.  GPU Backend (CUDA C++): A standalone shared library (`.dll`) containing optimized kernels for 2D convolutions.



---

## Core Features

### 1. Real-Time Convolution Engine
The heart of the editor is the **Matrix Convolution Library**. It supports various image filters by applying a sliding kernel (Mean Filter, Gaussian Blur, Laplacian, etc.) across the image matrix.
* **ARGB Support:** Processes 32-bit integer pixels by decomposing them into 4 independent 8-bit channels ($A, R, G, B$) within the GPU registers.
* **Thread Optimization:** Dynamically calculates grid and block dimensions based on the image size to maximize GPU occupancy.

### 2. Hardware Acceleration
Users can toggle between CPU-based processing and GPU-based processing. The GPU path utilizes the **Parallel Thread Execution (PTX)** capabilities of NVIDIA hardware, significantly reducing latency on high-resolution images.



---

## Hardware & Software Requirements

| Requirement | Specification |
| :--- | :--- |
| **GPU** | NVIDIA GeForce/Quadro (Compute Capability 3.0+) |
| **Driver** | NVIDIA Game Ready or Studio Driver (v450+) |
| **Runtime** | .NET 6.0 / .NET Framework 4.8 |
| **OS** | Windows 10 or 11 (x64) |

---

## Implementation Reference

### C# Integration (P/Invoke)
The project utilizes a wrapper to call the unmanaged CUDA functions. You can find the specific implementation of the memory pinning and DLL entry points here:

> **[CudaConvolutionWrapper.cs](https://github.com/ObiWanKenobi98/ImageEditor/blob/main/Cuda/CudaConvolutionWrapper.cs#L11)**

### GPU Kernel Logic
The underlying math for the convolution is handled by a 3x3 mean filter approximation:
$$P[x,y]_{t+1} = \frac{1}{9} \sum_{i=-1}^{1} \sum_{j=-1}^{1} P[x+j, y+i]_{t}$$



---

## Roadmap

* **[ ] Dynamic Fallback:** Automatically switch to CPU processing if no CUDA-compatible device is detected.
* **[ ] Advanced Kernels:** Add support for Sobel Edge Detection and Sharpening filters.
* **[ ] Shared Memory:** Optimize the CUDA kernel to use **Shared Memory (L1 Cache)** to reduce Global Memory latency during matrix reads.
* **[ ] Multi-Platform:** Implement a Linux-compatible build using `.so` files and `ILGPU`.

---

## Compilation & Setup

1.  **Build the DLL:** Open the Cuda project in Visual Studio and build the solution to generate `cudaConvolutionLibrary.dll`.
2.  **Link the UI:** Ensure the `.dll` is in the same directory as the compiled C# `.exe`.
3.  **Run:** Open an image and select a filter to trigger the GPU kernel.

---