#include "blp.h"

uint8_t* ProcessBLP(BinaryReader bin, int width, int height, int channels) {
	return load(bin, width, height, channels);
}